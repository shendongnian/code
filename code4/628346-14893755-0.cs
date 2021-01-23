        public ActionResult ViewStages()
        {
            Stages viewModel=new Stages()  //here you have to initialize your model
            {
               Id=1,
               Code="any code",
             //etc
            }
            return View(viewModel);   //you have to pass the model to the view
        }
