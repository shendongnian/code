        public int? Save(DocumentNote entity, bool autoFlush)
        {
            var persisted = (DocumentNote)CurrentSession.Merge(entity);
            entity.DocDataNoteID = persisted.DocDataNoteID;
            if (autoFlush)
            {
                CurrentSession.Flush();
                CurrentSession.Evict(persisted);
            }
            
            return entity.DocDataNoteID;
        }
