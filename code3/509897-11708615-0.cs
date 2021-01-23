    using Visio = Microsoft.Office.Interop.Visio;
    visioObj = (Visio.Application)				    
         System.Runtime.InteropServices.Marshal.GetActiveObject("Visio.Application");
    Array ids = shape.ConnectedShapes(Visio.VisConnectedShapesFlags
            .visConnectedShapesAllNodes, "");
    // Using first item and get name   
    string name = visioObj.ActivePage.Shapes[ids.GetValue(0)].Name;
