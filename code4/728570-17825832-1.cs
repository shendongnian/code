    texture2D Input0;
    sampler2D Input0Sampler = sampler_state
    {
        Texture = <Input0>;
        MinFilter = Point;
        MagFilter = Point;
        MipFilter = Point;
        AddressU = Clamp;
        AddressV = Clamp;
    };
    
    texture2D Input1;
    sampler2D Input1Sampler = sampler_state
    {
        Texture = <Input1>;
        MinFilter = Point;
        MagFilter = Point;
        MipFilter = Point;
        AddressU = Clamp;
        AddressV = Clamp;
    };
    
    texture2D Input2;
    sampler2D Input2Sampler = sampler_state
    {
        Texture = <Input2>;
        MinFilter = Point;
        MagFilter = Point;
        MipFilter = Point;
        AddressU = Clamp;
        AddressV = Clamp;
    };
    
    texture2D Input3;
    sampler2D Input3Sampler = sampler_state
    {
        Texture = <Input3>;
        MinFilter = Point;
        MagFilter = Point;
        MipFilter = Point;
        AddressU = Clamp;
        AddressV = Clamp;
    };
    
    
    struct VertexShaderInput
    {
        float4 Position : POSITION0;
    	float2 TextureCoordinate : TEXCOORD0;
    };
    
    struct VertexShaderOutput
    {
        float4 Position : POSITION0;
    	float2 TextureCoordinate : TEXCOORD0;
    };
    
    struct PixelShaderOutput
    {
    	// TODO: Optionally add/remove output indices to match GPUProcessor.numOutputs
    	float4 Index0 : COLOR0;
    };
    
    // input texture dimensions
    static const float w = 1920;
    static const float h = 1080;
    
    static const float2 pixel = float2(1.0 / w, 1.0 / h);
    static const float2 halfPixel = float2(pixel.x / 2, pixel.y / 2);
    
    
    VertexShaderOutput VertexShaderFunction(VertexShaderInput vsInput)
    {
        //VertexShaderOutput output;
        
        //output.Position = vsInput.Position;
    	//output.TextureCoordinate = vsInput.TextureCoordinate;
    	
    	VertexShaderOutput output;
        vsInput.Position.x =  vsInput.Position.x - 2*halfPixel.x;
        vsInput.Position.y =  vsInput.Position.y + 2*halfPixel.y;
        output.Position = vsInput.Position;
        output.TextureCoordinate = vsInput.TextureCoordinate ;
        return output;
    	
    
        //return output;
    }
    
    PixelShaderOutput PixelShaderFunction(VertexShaderOutput psInput)
    {
    	PixelShaderOutput output;
    	// TODO: Optionally add/remove samples to match GPUProcessor.numInputs
    	float4 input0 = tex2D(Input0Sampler, psInput.TextureCoordinate);
    	//float4 input1 = tex2D(Input0Sampler, psInput.TextureCoordinate);
    	//float4 input2 = tex2D(Input0Sampler, psInput.TextureCoordinate);
    	//float4 input3 = tex2D(Input0Sampler, psInput.TextureCoordinate);
    
    	// your calculations go here
    		
    	// TODO: Optionally add/remove outputs to match GPUProcessor.numOutputs
    	output.Index0 = input0;//float4(100,200,13,24);//input0;
    	
    	return output;
    }
    
    technique Verlet
    {
        pass Go
        {
    	    VertexShader = compile vs_2_0 VertexShaderFunction();
            PixelShader = compile ps_2_0 PixelShaderFunction();
        }
    }
