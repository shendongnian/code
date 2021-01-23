    private SomeObject o = new SomeObject();
    private void o_SomeEvent(...) {
    }
    
    public TheConstructor() {
        this.o.SomeEvent += new SomeHandler(o_SomeEvent);
    }
