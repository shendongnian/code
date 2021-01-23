            public ActionResult SomeAction()
        {
            int something = 0;
            try
            {
                int y = 3 / something;  //Intentional Exception
                return new ActionResult();
            }
            catch (Exception e)
            {
                throw;
            }
        }
