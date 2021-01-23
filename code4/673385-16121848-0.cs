     public abstract class Document
    {
        /*Assuming OpenFile and SaveFile are the same for Word, Excel and Microstation */
        public void DoStuff()
        {
            OpenFile();
            DoSpecificStuff();
            SaveFile();
        }
        private void OpenFile()
        {
            //Open the file here.
        }
        protected abstract void DoSpecificStuff()
        {
            //Word, Excel and Microstation override this method.
        }
        private void SaveFile()
        {
            //Save file
        }
    }
    public class Excel : Document
    {
        protected override void DoSpecificStuff()
        {
            //Excel does what it needs to do.
        }
    }
    public class Word : Document
    {
        protected override void DoSpecificStuff()
        {
            //Word does what it needs to do.
        }
    }
