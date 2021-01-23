        internal void PrePush(object expectedOwner)
        {
            lock (this) {
                //3 // The following tests are retail assertions of things we can't allow to happen.
                if (null == expectedOwner) {
                    if (null != m_Owner && null != m_Owner.Target)
                        throw new InternalException();
                    // new unpooled object has an owner
                }
                else {
                    if (null == m_Owner || m_Owner.Target != expectedOwner)
                        throw new InternalException();
                    // unpooled object has incorrect owner
                }
               
                m_PooledCount++;
               
                if (1 != m_PooledCount)
                    throw new InternalException();
                // pushing object onto stack a second time
                if (null != m_Owner)
                    m_Owner.Target = null;
            }
        }
