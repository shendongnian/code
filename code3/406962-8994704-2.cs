    #region Originator
    public class Originator<T>
    {
       #region Properties
       public T State { get; set; }
       #endregion
       #region Methods
       /// <summary>
       /// Creates a new memento to hold the current
       /// state
       /// </summary>
       /// <returns>The created memento</returns>
       public Memento<T> SaveMemento()
       {
          return (new Memento<T>(State));
       }
       /// <summary>
       /// Restores the state which is saved in the given memento
       /// </summary>
       /// <param name="memento">The given memento</param>
       public void RestoreMemento(Memento<T> memento)
       {
          State = memento.State;
       }
       #endregion
    }
    #endregion
    #region Memento
    public class Memento<T>
    {
       #region Properties
       public T State { get; private set; }
       #endregion
       #region Ctor
       /// <summary>
       /// Construct a new memento object with the
       /// given state
       /// </summary>
       /// <param name="state">The given state</param>
       public Memento(T state)
       {
          State = state;
       }
       #endregion
    }
    #endregion
    #region Caretaker
    public class Caretaker<T>
    {
       #region Properties
       public Memento<T> Memento { get; set; }
       #endregion
    }
    #endregion
    #region Originator
    public class Originator<T>
    {
       #region Properties
       public T State { get; set; }
       #endregion
       #region Methods
       /// <summary>
       /// Creates a new memento to hold the current
       /// state
       /// </summary>
       /// <returns>The created memento</returns>
       public Memento<T> SaveMemento()
       {
          return (new Memento<T>(State));
       }
       /// <summary>
       /// Restores the state which is saved in the given memento
       /// </summary>
       /// <param name="memento">The given memento</param>
       public void RestoreMemento(Memento<T> memento)
       {
          State = memento.State;
       }
       #endregion
    }
    #endregion
    #region Memento
    public class Memento<T>
    {
       #region Properties
       public T State { get; private set; }
       #endregion
       #region Ctor
       /// <summary>
       /// Construct a new memento object with the
       /// given state
       /// </summary>
       /// <param name="state">The given state</param>
       public Memento(T state)
       {
          State = state;
       }
       #endregion
    }
    #endregion
    #region Caretaker
    public class Caretaker<T>
    {
       #region Properties
       public Memento<T> Memento { get; set; }
       #endregion
    }
    #endregion
