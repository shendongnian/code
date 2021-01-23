    private void enumCheckedChanged(Checkbox pBox, bool pbAddFirst) {
        RightsEnum flag = pBox.Tag as RightsEnum;
        if (pBox.Checked && pbAddFirst) {
             count++;
             rights |= flag;
        }
        else if (pBox.Checked && !pbAddFirst) {
             rights |= flag;
             count++;
        }
        // Having checked for both variations of pbAddFirst, the only thing left would be if pBox.Checked is false
        else {
             rights ^= flag;
             count--;
        }
    }
