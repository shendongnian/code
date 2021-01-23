    // The Model
    public class JobActionFormModel {
        public  JobsDetailModel InputModel {get;set;}
        public IEnumerable<JobType> JobTypes {get;set;}
        public IEnumerable<InstituteType> InstituteTypes {get;set;}
    }
    
    // The way you build it
    [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
    public ActionResult PostJobAction(FormCollection PostJobForm, HttpPostedFileBase uploadfile, JobsDetailModel objLocationModel)
    {
        var model = new JobActionFormModel {
          InputModel = objLocationModel,
          JobTypes = create_this_list(),
          InstituteTypes = create_this_list_also(),
        }
        return View(objLocationModel);
    }
    
    // The way you consume it on your view
    <td width="319" height="30" align="left">
        @Html.DropDownListFor(x => x.InstituteType, new SelectList(Model.InstituteTypes, "Id", "Value", Model.InstituteType, new { @class="select" })
    </td>
    // same goes for all your lists
