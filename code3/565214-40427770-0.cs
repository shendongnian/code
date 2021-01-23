    var input = new BufferBlock<int>();
    var tb = new TransformBlock<int, int>(i => i * 2);
    var output = new BufferBlock<int>();
    // valid integers will pass to the transform
    input.LinkTo(tb, i => ValidateInput(i));
    // not valid will be discarded
    input.LinkTo(DataflowBlock.NullTarget<int>());
    // transformed data will come to the output
    tb.LinkTo(output);
