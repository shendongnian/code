    private void ApplicationFormReturnedCheck(ref IList<Subcontractor> list)
    {
        var isFormReturned = new Func<Subcontractor,bool>(
              x => x.ApplicationFormReturned != null);
        var isBeforeDate = new Func<Subcontractor,bool>(
              x => x.ApplicationFormReturned < this.ApplicationFormReturned);
        var isFormReturnedOrBeforeDate= new Func<Subcontractor,bool>(
              x => isFormReturned(x) || isFormReturnedBeforeDate(x));
        if (this.ApplicationFormNotReturnedFlag == true && this.ApplicationFormReturned != null)
        {
            list = list.Where(isFormReturnedOrBeforeDate).ToList();
        }
        else if (this.ApplicationFormNotReturnedFlag == true)
        {
            list = list.Where(isFormReturned).ToList();
        }
        else if (this.ApplicationFormReturned != null)
        {
            list = list.Where(isBeforeDate).ToList();
        }
    }
