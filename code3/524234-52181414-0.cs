     public class GenericApiController<TEntity> : BaseApiController
        where TEntity : class, new()
    {
        [HttpGet]
        [Route("api/{Controller}/{id}")]       
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = db.Set<TEntity>().Find(id);
                if(entity==null)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("api/{Controller}")]
        public IHttpActionResult Post(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var primaryKeyValue = GetPrimaryKeyValue(entity);
                var primaryKeyName = GetPrimaryKeyName(entity);
                var existing = db.Set<TEntity>().Find(primaryKeyValue);
                ReflectionHelper.Copy(entity, existing, primaryKeyName);
                db.Entry<TEntity>(existing).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("api/{Controller}/{id}")]
        public IHttpActionResult Put(int id, TEntity entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var existing = db.Set<TEntity>().Find(id);
                if (entity == null)
                {
                    return NotFound();
                }
                ReflectionHelper.Copy(entity, existing);
                db.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        [Route("api/{Controller}/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = db.Set<TEntity>().Find(id);
                if(entity==null)
                {
                    return NotFound();
                }
                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        protected internal int GetPrimaryKeyValue(TEntity entity)
        {
            return ReflectionHelper.GetPrimaryKeyValue(entity);
        }
        protected internal string GetPrimaryKeyName(TEntity entity)
        {
            return ReflectionHelper.GetPrimaryKeyName(entity);
        }
        protected internal bool Exists(int id)
        {
            return db.Set<TEntity>().Find(id) != null;
        }
    }
