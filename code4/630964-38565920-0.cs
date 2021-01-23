            ObjectStateEntry entry;
            // Track whether we need to perform an attach
            bool attach;
            if (ObjectContext.ObjectStateManager.TryGetObjectStateEntry(ObjectContext.CreateEntityKey("Requests", currentRequest), out entry))
            {
                // Re-attach if necessary
                attach = entry.State == EntityState.Detached;
            }
            else
            {
                // Attach for the first time
                attach = true;
            }
            if (attach)
            {
                ObjectContext.DocumentRequests.AttachAsModified(currentRequest, original);
            }
            else
            {
                ObjectContext.Requests.ApplyCurrentValues(currentRequest);
            }
