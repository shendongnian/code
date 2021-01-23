          if(useSimulator)
          {
            string xxx = String.Format("{0}", ((char)27));
            string testString = testPrint.ToString();
            testString = testString.Replace(xxx, "\\");
            logger.Debug("text to print is [{0}]", testString);
            posPrinter.PrintNormal(PrinterStation.Receipt, testString); 
          }
          else
            posPrinter.PrintNormal(PrinterStation.Receipt, testPrint.ToString());
