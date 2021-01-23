        public static void CheckIfModified(EntityObject entity, ObjectContext context)
        {
            if (entity.EntityState == EntityState.Modified)
            {
                ObjectStateEntry state = context.ObjectStateManager.GetObjectStateEntry(entity);
                DbDataRecord orig = state.OriginalValues;
                CurrentValueRecord curr = state.CurrentValues;
                bool changed = false;
                for (int i = 0; i < orig.FieldCount && !changed; ++i)
                {
                    object origValue = orig.GetValue(i);
                    object curValue = curr.GetValue(i);
                    if (!origValue.Equals(curValue) && (!(origValue is byte[]) || !((byte[])origValue).SequenceEqual((byte[])curValue)))
                    {
                        changed = true;
                    }
                }
                if (!changed)
                {
                    state.ChangeState(EntityState.Unchanged);
                }
            }
        }
