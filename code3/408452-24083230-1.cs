                throw;
            }
            catch (Common.Exception<SessionDescription>)
            {
                Common.ExceptionExtensions.CreateAndRaiseException(this, "Unable to describe media, Session Description Exception Occured.");
            }`
