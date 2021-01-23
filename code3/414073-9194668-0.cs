      ConfirmDialogHandler handler = new ConfirmDialogHandler();
      using (new UseDialogOnce(browser.DialogWatcher, handler))
      {
          browser.Link(Find.ByClass("Your class")).ClickNoWait(); //The action that triggers the dialog
          handler.WaitUntilExists(60);
          handler.OKButton.Click();
      }
