        public interface IInputLayoutMaker
        {
            InputLayout MakeInputLayout(Device device, SlimDX.D3DCompiler.ShaderSignature inputSignature);
        }
        public abstract class ShaderBase
        {
            protected ShaderBase(Device device, string vertexShaderString, string pixelShaderString, IInputLayoutMaker inputLayoutMaker)
            {
                ShaderSignature inputSignature;
                using (ShaderBytecode bytecode = ShaderBytecode.CompileFromFile(vertexShaderString, "VShader", "vs_4_0", ShaderFlags.None, EffectFlags.None))
                {
                    vertexShader = new VertexShader(device, bytecode);
                    inputSignature = ShaderSignature.GetInputSignature(bytecode);
                }
                inputLayout = inputLayoutMaker.MakeInputLayout(device,inputSignature);
            }
            protected abstract InputLayout MakeInputLayout(Device device, ShaderSignature inputSignature);
        }
        public class TextureShader:ShaderBase
        {
            private class TextureShaderInputLayoutMaker : IInputLayoutMaker
            {
                public InputLayout MakeInputLayout(Device device, SlimDX.D3DCompiler.ShaderSignature inputSignature)
                {
                    return new InputLayout(device, inputSignature, new[] { 
                        new InputElement("POSITION", 0, SlimDX.DXGI.Format.R32G32B32_Float, 0), 
                        new InputElement("COLOR",0,SlimDX.DXGI.Format.R32G32B32_Float,0)
                    });
                }
            }
            public ColourShader(Device device) : base(device,"shaders/colour.fx", "shaders/colour.fx", new TextureShaderInputLayoutMaker())
            {
            }
        }
