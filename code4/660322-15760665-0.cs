    public class DataRowSafe
    {
        public void Get(String Column, ref string myParam)
        {
            myParam = String.Empty;
        }
        public void Get(String Column,ref int myParam)
        {
            myParam = 0;
        }
    }
    int i = 0;
    string st = "";
    new DataRowSafe().Get("name", ref i);
    new DataRowSafe().Get("name", ref st);
