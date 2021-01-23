        public HttpResponseMessage GetComputingDevice(string id)
        {
            ComputingDevice computingDevice =
                _db.Devices.OfType<ComputingDevice>()
                    .SingleOrDefault(c => c.AssetId == id);
            if (computingDevice == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }
            if (this.Request.ClientHasStaleData(computingDevice.ModifiedDate))
            {
                return this.Request.CreateResponse<ComputingDevice>(
                    HttpStatusCode.OK, computingDevice);
            }
            else
            {
                return this.Request.CreateResponse(HttpStatusCode.NotModified);
            }
        }
