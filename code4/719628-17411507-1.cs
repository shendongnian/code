    public IEnumerable<YourDataType> InventSomeData(int count) {
        for(int i = 0 ; i < count ; i++) {
            var obj = new YourDataType {
               ... initialize your random per row values here...
            }
            yield return obj;
        }
    }
