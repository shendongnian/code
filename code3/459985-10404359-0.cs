        enum RestartStatus{success, unableToRestart, unableToApplySettings};
        RestartStatus status = RestartStatus.success;
        applyChangesAndCheckRestartService(status);
        if(status != RestartStatus.success) //....
        private void applyChangesAndCheckRestartService(out RestartStatus status)
        {
            // set the status variable accordingly
        }
