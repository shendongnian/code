      public bool IsAccept()
        {
            //check the status is accept
            return Status == null ? false : Status.ToLower() == "accept";
        }
