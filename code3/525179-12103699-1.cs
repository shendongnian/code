            string sFileContents = "";
            using (StreamReader oStreamReader = new StreamReader(File.OpenRead("Test.csv")))
            {
                sFileContents = oStreamReader.ReadToEnd();
            }
            List<string[]> oCsvList = new List<string[]>();
            string[] sFileLines = sFileContents.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string sFileLine in sFileLines)
            {
                oCsvList.Add(sFileLine.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
            }
            int iColumnNumber = 0;
            int iRowNumber = 0;
            Console.WriteLine("Column{0}, Row{1} = \"{2}\"", iColumnNumber, iRowNumber, oCsvList[iColumnNumber][iRowNumber]);
            iColumnNumber = 4;
            iRowNumber = 2;
            Console.WriteLine("Column{0}, Row{1} = \"{2}\"", iColumnNumber, iRowNumber, oCsvList[iColumnNumber][iRowNumber]);
