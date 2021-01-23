    [Authorize]
    public class CutSheetController : AlumCloudWebApiBaseController
    {
        public async Task<HttpResponseMessage> Get(string a, string f, int id)
        {
            HttpResponseMessage r = Request.CreateResponse();
            IElevation elev = await ElevationManager.GetElevationAsync(id);
            CutSheet.CutSheet cutSheet = await AlumCloudPlans.Manager.GetCutSheetAsync(elev);
            ...
       }
    }
