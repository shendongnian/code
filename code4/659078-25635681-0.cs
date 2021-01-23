         // DELETE api/Scan/5
        [Route("api/scan/{id}")]
        [ResponseType(typeof(Scan))]
        public IHttpActionResult DeleteScan(int id)
        {
            Scan scan = db.Scans.Find(id);
            if (scan == null)
            {
                return NotFound();
            }
            db.Scans.Remove(scan);
            db.SaveChanges();
            return Ok(scan);
        }
