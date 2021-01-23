    public class ViewModelValidator : AbstractValidator<ViewModel>
    {
        public ViewModelValidator()
        {
            Custom(r => ContentIsEmpty(r) ? new ValidationFailure("Content", "Content must not be empty.") : null);
        }
        private static bool ContentIsEmpty(ViewModel viewModel)
        {
            return string.IsNullOrWhiteSpace(viewModel.Content);
        }
    }
