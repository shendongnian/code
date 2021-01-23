    ...other using statements...
    using MyProj.DAL;
    using MyProj.BO;
    public class MyController:Controller
    {
    //Create object of your Data Access Layer's MyDAL functionality
    MyDAL DALobj = new MyDAL();
    
    
    public ActionResult viewAList(){
    modelA mobj = DALobj.FetchObjFromDB();
    return View(mobj);
    }
    
    public ActionResult viewACreate(modelA newobj){
    ...check if modelstate is okay and tweak your model object here...
    DALobj.SendDataToDB(newobj);
    return RedirectToView("some other view | index");
    }
    
    
    public ActionResult viewBList(){
    ...same as viewAList() but with modelB this time...
    }
    
    public ActionResult viewBCreate(){
    ...same as viewACreate() but with modelB this time...
    }
    }//controller ends here
