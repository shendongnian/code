    using D3D = Microsoft.DirectX.Direct3D; 
    private D3D.Font text;
    private void InitializeFont() 
    { 
    System.Drawing.Font systemfont = new System.Drawing.Font("Arial", 12f, FontStyle.Regular);
     text = new D3D.Font(device, systemfont); 
    } 
