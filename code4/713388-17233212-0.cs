    struct VertexShaderOutput
    {
        float4 ClipPosition : POSITION; // Renamed this to ClipPosition.
        float4 Position : TEXCOORD0;    // This is valid to use as an input to the pixel shader.
        float3 Normal : NORMAL;
        float3 ExactPos : TEXCOORD1;
    };
    
    struct PSOutput
    {
        float4 col : COLOR0;
        float dept : DEPTH;
    };
    
    VertexShaderOutput VSFunction(VertexShaderInput input)
    {
        VertexShaderOutput output;
    
        float4 worldPosition = mul(input.Position, World);
        float4 viewPosition = mul(worldPosition, View);
        output.ClipPosition = mul(viewPosition, Projection); 
        output.Position = output.ClipPosition; // Copy output position to our other attribute.
        output.Normal = mul(input.Normal, World);
        output.ExactPos = input.Position;
    
        return output;
    }
