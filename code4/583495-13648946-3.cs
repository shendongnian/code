        [HttpGet]
        public NJsonResult GetAllProjectsExcept(string ids)
        {
            var result = ExecuteCommand(new GetProjects
                                            {
                                                IDs = ids
                                            });
            //...
        }
