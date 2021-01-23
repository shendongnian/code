    [HttpPost, ActionName("Edit")]
    public virtual ActionResult Edit_Post(ENT obj)
    {
    
      ...code...
    
      Ctxt.Set<ENT>().Attach(obj);
      Ctxt.Entry(obj).State = EntityState.Modified;
      Ctxt.RestrictModifiedProps(obj, this.JsonPostPropNames());
    
      ...code...
    
    }
