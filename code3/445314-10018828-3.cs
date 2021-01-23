        public void DoEachMember<TAttribute, TMembertype>(IEnumerable<TMembertype> members,
                                 Func<TMembertype, object> valueGetter)
            where TMembertype : MemberInfo
        {
            foreach (var mi in members)
            {
                if (mi.GetCustomAttributes(typeof(TAttribute), true).Any())
                {
                    // Get value of field.
                    object value = valueGetter(mi);
                    DoAction(value);
                }
            }
        }
