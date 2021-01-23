    [HttpPost]
            public ActionResult Create(CreateVeiwModel model)
            {
                if (ModelState.IsValid)
                try
                {
                    Repository.AddSpeaker(model.Speaker);
                ...
            }
