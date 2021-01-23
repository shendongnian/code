    using System;
    using System.Runtime.InteropServices;
    public static class Extensions
    {
        public staitc TDestination[] Transform<TSource, TDestination>(
            this TSource[] source)
            where TSource : struct
            where TDestination : struct
        {
            if (source.Length == 0)
            {
                return new TDestination[0];
            }
            var sourceSize = Marshal.SizeOf(typeof(TSource));
            var destinationSize = Marshal.SizeOf(typeof(TDestination));
            var byteLength = source.Length * sourceSize;
            int remainder;
            var destinationLength = Math.DivRem(
                byteLength,
                destinationSize,
                out remainder);
            if (remainder > 0)
            {
                destinationLength++;
            }
            var destination = new TDestination[destinationLength];
            Buffer.BlockCopy(source, 0, destination, 0, byteLength);
            return destination;
        }
    }
