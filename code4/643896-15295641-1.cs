    public void MyMethod(Func<int> expression) {
        // Does work
    }
    public int GetProperty() {
        return 123;
    }
    pubic void Test() {
        MyMethod(GetProperty /* NO PARENTHESES HERE!!! */);
    }
