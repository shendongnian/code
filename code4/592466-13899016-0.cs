    public Form1() {
      test = new Test(this);
    }
    class Test {
      private Form1 form;
      public Test(Form1 f) {
        form = f;
      }
      ...
