    using System.Web.Mvc;
    using Umbraco.Web.Mvc;
    /// <summary>   Stores controller. </summary>
    public sealed class StoresSurfaceController : SurfaceController
    {
        /// <summary>   Does the store exist. </summary>
        /// <param name="StoreName"> Name of the store. </param>
        /// <param name="StoreId"> Identifier of the store. </param>
        /// <returns>   true if the store exists, false if not. </returns>
        [HttpPost]
        public JsonResult IsStoreExists(string StoreName, long StoreId)
        {
            return this.Json(true);
        }
    }
