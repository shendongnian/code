    var inputTex2D = Texture2D.FromStream<Texture2D>(device, inputMemoryStream, (int)inputMemoryStream.Length, new ImageLoadInformation()
            {
                Depth = 1,
                FirstMipLevel = 0,
                MipLevels = 0,
                Usage = ResourceUsage.Default,
                BindFlags = BindFlags.ShaderResource,
                CpuAccessFlags = CpuAccessFlags.None,
                OptionFlags = ResourceOptionFlags.None,
                Format = Format.R8G8B8A8_UNorm,
                Filter = FilterFlags.None,
                MipFilter = FilterFlags.None,
            });
