     static void SetDefault(string signature)
        {
            Outlook.Application oApplication = ThisAddIn.app;
            Word.Application oWord = new Word.Application();
            Word.EmailOptions oOptions;
            oOptions = oWord.Application.EmailOptions;
            oOptions.EmailSignature.NewMessageSignature = signature;
            oOptions.EmailSignature.ReplyMessageSignature = signature;
            //Release Word
            if (oOptions != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(oOptions);
            if (oWord != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord);
        }
