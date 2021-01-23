c#
/// <summary>
/// Get the value of the radio button that is checked.
/// </summary>
/// <param name="buttons">The radio buttons to look through</param>
/// <returns>The name of the radio button that is checked</returns>
public static string GetCheckedRadioButton(params RadioButton[] radioButtons)
{
    // Look at each button, returning the text of the one that is checked.
    foreach (RadioButton button in radioButtons)
    {
        if (button.Checked)
            return button.Text;
    }
    return null;
}
