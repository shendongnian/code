    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace YourNamespace
    {
        public class ObjectDoesNotMatchTargetBaseTypeException : Exception
        {
            public ObjectDoesNotMatchTargetBaseTypeException(Type targetType, object actualObject)
                : base(string.Format("Expected base type ({0}) does not match actual objects type ({1}).",
                    targetType, actualObject.GetType()))
            {
            }
        }
        /// <summary>
        /// Allows you to react, when items were added or removed to a generic List.
        /// </summary>
        public abstract class NoisyList<TItemType> : List<TItemType>, IList
        {
            #region Public Methods
            /******************************************/
            int IList.Add(object item)
            {
                CheckTargetType(item);
                Add((TItemType)item);
                return Count - 1;
            }
            void IList.Remove(object item)
            {
                CheckTargetType(item);
                Remove((TItemType)item);
            }
            public new void Add(TItemType item)
            {
                base.Add(item);
                OnItemAdded(item);
            }
            public new bool Remove(TItemType item)
            {
                var result = base.Remove(item);
                OnItemRemoved(item);
                return result;
            }
            #endregion
            # region Private Methods
            /******************************************/
            private static void CheckTargetType(object item)
            {
                var targetType = typeof(TItemType);
                if (item.GetType().IsSubclassOf(targetType))
                    throw new ObjectDoesNotMatchTargetBaseTypeException(targetType, item);
            }
            #endregion
            #region Abstract Methods
            /******************************************/
            protected abstract void OnItemAdded(TItemType addedItem);
        
            protected abstract void OnItemRemoved(TItemType removedItem);
            #endregion
        }
    }
