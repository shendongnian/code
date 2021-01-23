    public List<MyItem> MyItems {
        get {
            return new List<MyItem>() {
                new MyItem() { 
                    HeaderA = "Foo0", 
                    HeaderB = "Bar0", 
                    MyContent = "This is content."
                },
                new MyItem() { 
                    HeaderA = "Foo1",
                    HeaderB = "Bar1",
                    MyContent = "This is content."}
                };
            }
        }
    }
