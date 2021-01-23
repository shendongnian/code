        public void ConfirmOKTest()
    {
        using (IE ie = new IE("http://localhost/confirmtest.htm"))
        {
            ConfirmDialogHandler handler = new ConfirmDialogHandler();
            using (new UseDialogOnce(ie.DialogWatcher, handler))
            {
                ie.Button("myButton1").ClickNoWait();
                handler.WaitUntilExists();
                handler.OKButton.Click();
            }
            ie.WaitForComplete();
            Assert.AreEqual("Clicked OK", ie.Button("myButton1").Text);
        }
    }
   
