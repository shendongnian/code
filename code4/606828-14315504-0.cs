    public class Form1
    {
        private DataSet _myDataSet;
        // do things
        private void fillMyDataSet()
        {
            //fill your dataset
        }
        public dataSet GetMyDataSet()
        {
            if(_myDataSet != null)
                return _myDataSet;
            else
            {
                return null;
            }
        }
    }
