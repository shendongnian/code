    public class ArrayFillBenchmark
    {
        const int length1 = 1000;
        const int length2 = 1000;
        readonly double[,] _myArray = new double[length1, length2];
        [Benchmark]
        public void MultidimensionalArrayLoop()
        {
            for (int i = 0; i < length1; i++)
            for (int j = 0; j < length2; j++)
                _myArray[i, j] = double.PositiveInfinity;
        }
        [Benchmark]
        public unsafe void MultidimensionalArrayNaiveUnsafeLoop()
        {
            fixed (double* a = &_myArray[0, 0])
            {
                double* b = a;
                for (int i = 0; i < length1; i++)
                for (int j = 0; j < length2; j++)
                    *b++ = double.PositiveInfinity;
            }
        }
        [Benchmark]
        public unsafe void MultidimensionalSpanFill()
        {
            fixed (double* a = &_myArray[0, 0])
            {
                double* b = a;
                var span = new Span<double>(b, length1 * length2);
                span.Fill(double.PositiveInfinity);
            }
        }
        [Benchmark]
        public unsafe void MultidimensionalSseFill()
        {
            var vectorPositiveInfinity = Vector128.Create(double.PositiveInfinity);
            fixed (double* a = &_myArray[0, 0])
            {
                double* b = a;
                ulong i = 0;
                int size = Vector128<double>.Count;
                ulong length = length1 * length2;
                for (; i < (length & ~(ulong)15); i += 16)
                {
                    Sse2.Store(b+size*0, vectorPositiveInfinity);
                    Sse2.Store(b+size*1, vectorPositiveInfinity);
                    Sse2.Store(b+size*2, vectorPositiveInfinity);
                    Sse2.Store(b+size*3, vectorPositiveInfinity);
                    Sse2.Store(b+size*4, vectorPositiveInfinity);
                    Sse2.Store(b+size*5, vectorPositiveInfinity);
                    Sse2.Store(b+size*6, vectorPositiveInfinity);
                    Sse2.Store(b+size*7, vectorPositiveInfinity);
                    b += size*8;
                }
                for (; i < (length & ~(ulong)7); i += 8)
                {
                    Sse2.Store(b+size*0, vectorPositiveInfinity);
                    Sse2.Store(b+size*1, vectorPositiveInfinity);
                    Sse2.Store(b+size*2, vectorPositiveInfinity);
                    Sse2.Store(b+size*3, vectorPositiveInfinity);
                    b += size*4;
                }
                for (; i < (length & ~(ulong)3); i += 4)
                {
                    Sse2.Store(b+size*0, vectorPositiveInfinity);
                    Sse2.Store(b+size*1, vectorPositiveInfinity);
                    b += size*2;
                }
                for (; i < length; i++)
                {
                    *b++ = double.PositiveInfinity;
                }
            }
        }
    }
Results:
|                               Method |       Mean |     Error |    StdDev | Ratio |
|------------------------------------- |-----------:|----------:|----------:|------:|
|            MultidimensionalArrayLoop | 1,083.1 us | 11.797 us | 11.035 us |  1.00 |
| MultidimensionalArrayNaiveUnsafeLoop |   436.2 us |  8.567 us |  8.414 us |  0.40 |
|             MultidimensionalSpanFill |   321.2 us |  6.404 us | 10.875 us |  0.30 |
|              MultidimensionalSseFill |   231.9 us |  4.616 us | 11.323 us |  0.22 |
`MultidimensionalArrayLoop` is slow because of bounds checking. The JIT emits code each loop that makes sure that `[i, j]` is inside the bounds of the array. The JIT can elide bounds checking sometimes, I know it does for single-dimensional arrays. I'm not sure if it does it for multi-dimensional.
`MultidimensionalArrayNaiveUnsafeLoop` is essentially the same code as `MultidimensionalArrayLoop` but without bounds checking. It's considerably faster, taking 40% of the time. It's considered 'Naive', though, because the loop could still be improved by unrolling the loop.
`MultidimensionalSpanFill` also has no bounds check, and is more-or-less the same as `MultidimensionalArrayNaiveUnsafeLoop`, however, `Span.Fill` internally does loop unrolling, which is why it's a bit faster than our naive unsafe loop. It only take 30% of the time as our original.
`MultidimensionalSseFill` improves on our first unsafe loop by doing two things: loop unrolling and vectorizing. This requires a CPU with Sse2 support, but it allows us to write 128-bits (16 bytes) in a single instruction. This gives us an additional speed boost, taking it down to 22% of the original. Interestingly, this same loop with Avx (256-bits) was consistently slower than the Sse2 version, so that benchmark is not included here.
But these numbers only apply to an array that is 1000x1000. As you change the size of the array, the results differ. For example, when we change the array size to 10000x10000, the results for all of the unsafe benchmarks are very close. Probably because there are more memory fetches for the larger array that it tends to equalize the smaller iterative improvements seen in the last three benchmarks.
There's a lesson in there somewhere, but I mostly just wanted to share these results, since it was a pretty fun experiment to do.
