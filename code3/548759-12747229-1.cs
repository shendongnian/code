    [HttpPost]
            public void _SaveDocument(Model model, HttpPostedFileBase file)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath(@"Path"), fileName);
                    file.SaveAs(path);
    
                    var command = new command()
                    {
                        Model = model
                    };
                    commandDispatcher.Dispatch(command);
                }            
            }
