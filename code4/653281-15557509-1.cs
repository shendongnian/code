    if (viewModel.SelectedPaymentStatus != null) {
        // Let's do the conversion once, in C#
        List<int> statusIds = viewModel.SelectedPaymentStatus.Select( i => Convert.ToInt32(i) ).ToList();
        // Now select the matching orders
        queryOrder = queryOrder.Where(
                         m => statusIds.Contains(
                                  m.Payments.Select(p => p.PaymentStatusId).Single())
                              )
                     );
    }
