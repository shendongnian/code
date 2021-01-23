    public static Rectangle GetWorkingArea() {
        if (UseWantsItOnPrimaryScreen) {
            return SystemInformation.WorkingArea;
        }
        else {
            return Screen.AllScreens.FirstOrDefault(x => !x.Primary).WorkingArea;
        }
    }
