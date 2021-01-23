    private static void Test()
    {
        using (CudaContext ctx = new CudaContext())
        {
            CudaDeviceVariable<float> d = new CudaDeviceVariable<float>(3);
            CUmodule module = ctx.LoadModulePTX("test.ptx");
            CudaKernel kernel = new CudaKernel("test", module, ctx)
                {
                    GridDimensions = new dim3(1, 1),
                    BlockDimensions = new dim3(1, 1)
                };
            kernel.Run(d.DevicePointer);
        }
    }
