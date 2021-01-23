    using (ISession session = m_SessionFactory.OpenSession())
        {
            ICriteria criteria = session.CreateCriteria(typeof(Client));
            criteria.Add(Expression.Eq(propertyName, propertyValue));
            var list = criteria.List<Client>();
            if (!list.Any())
               return null;
            return new ClientDTO(list[0]);
        }
