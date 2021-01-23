    public class BaseModel<T> where T : Type
	{
		protected T Id;
		/// <summary>
		/// Adds a new record to data base. It doesn't check for record existance.
		/// </summary>
		/// <returns></returns>
		protected BaseModel<T> Add() 
		{
			try
			{
				var entities = Variable.CurrentEntities;
				var dbSet = entities.Set<BaseModel<T>>();
				var result = dbSet.Add(this);
				entities.SaveChanges();
				return result;
			}
			catch (Exception exception)
			{
				LogException.HandleException(exception);
				return null;
			}
		}
		protected bool Update()
		{
			try
			{
				var entities = Variable.CurrentEntities;
				var dbSet = entities.Set<BaseModel<T>>();
				var original = dbSet.Find(this);
				entities.Entry(original).CurrentValues.SetValues(this);
				entities.SaveChanges();
				return true;
			}
			catch (Exception exception)
			{
				LogException.HandleException(exception);
				return false;
			}
		}
		protected BaseModel<T> Delete()
		{
			try
			{
				var entities = Variable.CurrentEntities;
				var dbSet = entities.Set<BaseModel<T>>();
				var result = dbSet.Remove(this);
				entities.SaveChanges();
				return result;
			}
			catch (Exception exception)
			{
				LogException.HandleException(exception);
				return null;
			}
		}
		protected bool Upsert()
		{
			try
			{
				var entities = Variable.CurrentEntities;
				var dbSet = entities.Set<BaseModel<T>>();
				dbSet.AddOrUpdate(this);
				return true;
			}
			catch (Exception exception)
			{
				LogException.HandleException(exception);
				return false;
			}
		}
		protected BaseModel<T> Save()
		{
			try
			{
				var entities = Variable.CurrentEntities;
				var dbSet = entities.Set<BaseModel<T>>();
				var original = dbSet.Find(Id);
				if (original == null)
				{
					original = dbSet.Add(this);
				}
				else
				{
					entities.Entry(original).CurrentValues.SetValues(this);
				}
				entities.SaveChanges();
				return original;
			}
			catch (Exception exception)
			{
				LogException.HandleException(exception);
				return null;
			}
		}
	}
