        // PUT api/FlareForm/5
		public HttpResponseMessage PutFlareForm(int id, FlareForm flareform)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
			if (id != flareform.Id)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}
			List<int> previousIds = db.FlareForms.AsNoTracking().FirstOrDefault(ff => ff.Id == id).Tasks.Select(t => t.Id).ToList();
			List<int> currentIds = flareform.Tasks.Select(t => t.Id).ToList();
			List<int> deletedIds = previousIds
				.Except(currentIds).ToList();
			foreach (var deletedId in deletedIds)
			{
				FlareFormTask task = db.FlareFormTasks
					.Single(od => od.FlareFormId == flareform.Id && od.Id == deletedId);
				db.Entry(task).State = EntityState.Deleted;
			}
			foreach (var task in flareform.Tasks)
			{
				if (task.Id == 0)
				{
					task.FlareFormId = flareform.Id;
					db.Entry(task).State = EntityState.Added;
				}
				else
				{
					db.Entry(task).State = EntityState.Modified;
				}
			}
			db.Entry(flareform).State = EntityState.Modified;
			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
			}
			return Request.CreateResponse(HttpStatusCode.OK);
		}
