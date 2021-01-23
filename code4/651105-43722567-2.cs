    public ActionResult Action() {
	    long myJsTicks = DateTime.UtcNow.ToJavascriptTicks(); //<-- use the extension method
	
	    MyViewModel viewModel = new MyViewModel();
	    viewModel.MyJsTicks = myJsTicks;
	
	    return View(viewModel);
    }
  
