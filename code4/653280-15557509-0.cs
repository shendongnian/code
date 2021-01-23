    if (viewModel.SelectedPaymentStatus != null) {
        // Give me only orders from queryOrder where...
        queryOrder = queryOrder.Where(
            // ...my viewModel's SelectedPaymentStatus collection...
            m => viewModel.SelectedPaymentStatus.Contains(
                     // ...contains the order's payment's PaymentStatusId...
                     m.Payments.Select(p => p.PaymentStatusId).Single()
                                              // ... represented as a string?!
                                             .ToString()
                                              // Why are database IDs strings?
                 )
            );
    }
