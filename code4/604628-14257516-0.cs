    public void cmdTest_Click(object sender, EventArgs e)
    {
        Clipboard.SetData("MyCustomFormat", new MyData("This text should not be pasted"));
        if(Clipboard.ContainsData("MyCustomFormat"))
        {
            MyData result = Clipboard.GetData("MyCustomFormat") as MyData;
            MessageBox.Show(result.MyValue);
        }	
    }
    
    [Serializable]
    class MyData
    {
        string _internalValue;
        public MyData(string newValue)
        { _internalValue = newValue;}
        public string MyValue
        {
            get{return _internalValue;}
        }
    }
