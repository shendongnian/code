    bool IsLocked = repUser.IsLockedOut(txtDetailUserName.Value);
    if (IsLocked)
    {
         butUnlockUser.Disabled = false;
         butUnlockUser.CssClass ="class1";
    }
    else
    {
         butUnlockUser.Disabled = true;
         butUnlockUser.CssClass ="class2";
    }
