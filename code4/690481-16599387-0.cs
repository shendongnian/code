    private class MyData
    {
        // ...
    }
    private List<MyData> myDataList = new List<MyData>();
    public void SomeMethod()
    {
        MyData myData = ...;
        int position = myDataList.IndexOf(myData);
    }
