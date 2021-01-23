    var print = new PrintOperation();
    print.BeginPrint += (obj, args) => { print.NPages = 1; };
    print.DrawPage += (obj, args) => {
        PrintContext context = args.Context;
        Cairo.Context cr = context.CairoContext;
        var imageSurface = new Cairo.ImageSurface(printImage.FileName);
    
        int w = imageSurface.Width;
        int h = imageSurface.Height;
        cr.Scale(256.0/w, 256.0/h);
        cr.SetSourceSurface(imageSurface, 0,0); 
        cr.Paint();         
    };
    print.EndPrint += (obj, args) => { };
    print.Run(PrintOperationAction.Print, null);
