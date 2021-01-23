    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using My.Models;
    using System.Data.Entity.Validation;
    namespace My.Controllers.Api
    {
      public abstract class CrudController<TEntity>
        : ApiController where TEntity : class
      {
        private readonly MyContext _db = new MyContext();
        private readonly DbSet<TEntity> _dbSet;
        protected CrudController(Func<MyContext, DbSet<TEntity>> dbSet)
        {
          _db = new EtlContext();
          _dbSet = dbSet(_db);
        }
        public IEnumerable<TEntity> Get()
        {
          return _dbSet.AsEnumerable();
        }
        public HttpResponseMessage Post(TEntity entity)
        {
          try
          {
            if (!ModelState.IsValid)
              return Request.CreateResponse(HttpStatusCode.BadRequest);
            _db.Entry(entity).State = EntityState.Added;
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created);
          }
          catch (DbEntityValidationException)
          {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
          }
          catch (DbUpdateException)
          {
            return Request.CreateResponse(HttpStatusCode.Conflict);
          }
        }
        public HttpResponseMessage Put(TEntity entity)
        {
          try
          {
            if (!ModelState.IsValid)
              return Request.CreateResponse(HttpStatusCode.BadRequest);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
          }
          catch (DbEntityValidationException)
          {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
          }
          catch (DbUpdateConcurrencyException)
          {
            return Request.CreateResponse(HttpStatusCode.NotFound);
          }
          catch (DbUpdateException)
          {
            return Request.CreateResponse(HttpStatusCode.Conflict);
          }
        }
        public HttpResponseMessage Delete(TEntity entity)
        {
          try
          {
            _db.Entry(entity).State = EntityState.Deleted;
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
          }
          catch (DbUpdateConcurrencyException)
          {
            return Request.CreateResponse(HttpStatusCode.NotFound);
          }
        }
        protected override void Dispose(bool disposing)
        {
          _db.Dispose();
          base.Dispose(disposing);
        }
      }
    }
