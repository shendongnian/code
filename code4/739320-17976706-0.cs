    public class BeltPrinterFactory : IBeltPrinterFactory
    {
      public IBeltPrinter NewBeltPrinter()
      {
        BeltPrinter item = new BeltPrinter();
        switch (printerChoice)
        {
          case BeltPrinterType.ZebraQL220: 
            item.FunctionCall = ZebraCallback;
          case BeltPrinterType.ONiel: 
            item.FunctionCall = ONielCallback;
          default: 
            // do nothing;
        }
        return item;
      }
    }
