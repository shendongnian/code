    using System.Linq;
    private static string[] ValidAnswers = new string[]{ "y", "yes" };
    // Method to check if item is food or not
    private void ReadIfFoodItem() {
        Console.Write("Enter if food item or not (y/n): ");
        string ans = Console.ReadLine();
        // Checks if the answer matches any of the valid ones, ignoring case.
        if (PositiveAnswers.Any(a => string.Compare(a, ans, true) == 0)) {
            foodItem = true;
            selectedVATRate = 12; // Extra variable to store type of VAT
        } else {
            foodItem = false;
            selectedVATRate = 25; // Extra variable to store type of VAT
        }
    }
