        protected Employee GetEmployee()
        {
            if (Session["Employee"] != null)
            {
                // needs to be cast
                return (Employee)Session["Employee"];
            }
            else
            {
                return null;
            }
        }
